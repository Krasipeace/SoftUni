output "webapp_url" {
  value = azurerm_linux_web_app.alwa.default_hostname
}
output "webapp_ip-s" {
  value = azurerm_linux_web_app.alwa.outbound_ip_addresses
}