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

resource "azurerm_resource_group" "kravedra-resources" {
  name     = "kravedra-resources"
  location = "West Europe"
  #   managed_by = "id_of_the_resource_group_that_this_resource_group_is_managed_by"
  #   tags = {
  #     environment = "Production"
  #   }
}
