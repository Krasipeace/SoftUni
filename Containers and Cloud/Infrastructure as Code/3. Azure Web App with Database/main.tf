terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.90.0"
    }
  }
}

provider "azurerm" {
  features {}
  subscription_id = "your_SUPER-SECRET_subscription_id"
}

# Create an Azure resource group
resource "azurerm_resource_group" "arg" {
  name     = var.resource_group_name
  location = var.resource_group_location
}

# Create an App Service Plan
resource "azurerm_service_plan" "aas" {
  name                = var.app_service_plan_name
  location            = azurerm_resource_group.arg.location
  resource_group_name = azurerm_resource_group.arg.name
  os_type             = "Linux"
  sku_name            = "F1"
}

# Create a MSSQL Server
resource "azurerm_mssql_server" "ams" {
  name                         = var.sql_server_name
  resource_group_name          = azurerm_resource_group.arg.name
  location                     = azurerm_resource_group.arg.location
  version                      = "12.0"
  administrator_login          = var.sql_admin_login
  administrator_login_password = var.sql_admin_password
}

# Create a MSSQL Database
resource "azurerm_mssql_database" "amd" {
  name           = var.sql_database_name
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  sku_name       = "S0"
  zone_redundant = false
  server_id      = azurerm_mssql_server.ams.id
}

# Create a firewall rule for the MSSQL Server
resource "azurerm_mssql_firewall_rule" "amfr" {
  name             = var.firewall_rule_name
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
  server_id        = azurerm_mssql_server.ams.id
}

# Create a web app in the App Service Plan and configure it to use .NET 6.0 
resource "azurerm_linux_web_app" "alwa" {
  location            = azurerm_resource_group.arg.location
  name                = var.app_service_name
  resource_group_name = azurerm_resource_group.arg.name
  service_plan_id     = azurerm_service_plan.aas.id

  site_config {
    application_stack {
      dotnet_version = "6.0"
    }
    always_on = false
  }

  connection_string {
    name  = "DefaultConnection"
    type  = "SQLAzure"
    value = "Data Source=tcp:${azurerm_mssql_server.ams.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_mssql_database.amd.name};User ID=${azurerm_mssql_server.ams.administrator_login};Password=${azurerm_mssql_server.ams.administrator_login_password};Trusted_Connection=False; MultipleActiveResultSets=True;"
  }
}

# Deploy code from a public GitHub repository
resource "azurerm_app_service_source_control" "sc" {
  app_id                 = azurerm_linux_web_app.alwa.id
  repo_url               = var.repo_URL
  branch                 = "main"
  use_manual_integration = true
}
