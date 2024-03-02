variable "resource_group_name" {
  type        = string
  description = "Name of resource group"
}

variable "resource_group_location" {
  type        = string
  description = "Location of resource group"
}

variable "app_service_plan_name" {
  type        = string
  description = "App service plan name"
}

variable "app_service_name" {
  type        = string
  description = "App service name"
}

variable "sql_server_name" {
  type        = string
  description = "Sql server name"
}

variable "sql_database_name" {
  type        = string
  description = "Name of database"
}

variable "sql_admin_login" {
  type        = string
  description = "Username for sql server"
}

variable "sql_admin_password" {
  type        = string
  description = "Password for sql user"
}

variable "firewall_rule_name" {
  type        = string
  description = "Name of firewall rule"
}

variable "repo_URL" {
  type        = string
  description = "URL of GitHub repository"
}
