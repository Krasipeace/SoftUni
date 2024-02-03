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
}

# Generate a random integer to create a unique name for the web app
resource "random_integer" "ri" {
  min = 10000
  max = 99999
}

# Create an Azure resource group
resource "azurerm_resource_group" "arg" {
  name     = "ContactBookResourceGroup${random_integer.ri.result}"
  location = "West Europe"
}

# Create an App Service Plan
resource "azurerm_service_plan" "aas" {
  location            = azurerm_resource_group.arg.location
  name                = "contactBookSP${random_integer.ri.result}"
  resource_group_name = azurerm_resource_group.arg.name
  os_type             = "Linux"
  sku_name            = "F1"
}

# Create a web app
resource "azurerm_linux_web_app" "alwa" {
  location            = azurerm_resource_group.arg.location
  name                = "kravedra-ContactBook-${random_integer.ri.result}"
  resource_group_name = azurerm_resource_group.arg.name
  service_plan_id     = azurerm_service_plan.aas.id
  site_config {
    application_stack {
      node_version = "16-lts"
    }
    always_on = false
  }
}

# Deploy code from a public GitHub repository
resource "azurerm_app_service_source_control" "sc" {
  app_id                 = azurerm_linux_web_app.alwa.id
  repo_url               = "https://github.com/nakov/ContactBook"
  branch                 = "master"
  use_manual_integration = true
}
