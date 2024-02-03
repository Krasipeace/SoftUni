variable "resource_group_name" {
  type        = string
  description = "Name of the resource group in which the resources will be created"
}

variable "resource_group_location" {
  type        = string
  description = "Location of the resource group in which the resources will be created"
}

variable "app_service_plan_name" {
  type        = string
  description = "Name of the App Service Plan"
}

variable "app_service_name" {
  type        = string
  description = "Name of the App Service"
}

variable "sql_server_name" {
  type        = string
  description = "Name of the SQL Server"
}

variable "sql_database_name" {
  type        = string
  description = "Name of the SQL Database"
}

variable "sql_admin_login" {
  type        = string
  description = "SQL Server admin login"
}

variable "sql_admin_password" {
  type        = string
  description = "SQL Server admin password"
}

variable "firewall_rule_name" {
  type        = string
  description = "Name of the firewall rule"
}

variable "repo_URL" {
  type        = string
  description = "URL of the GitHub repository"
}
