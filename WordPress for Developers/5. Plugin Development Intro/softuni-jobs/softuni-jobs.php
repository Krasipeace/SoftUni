<?php
/*
 * Plugin Name:       SoftUni Jobs
 * Plugin URI:        https://softuni.bg
 * Description:       Our basic plugin for jobs
 * Version:           0.1
 * Requires at least: 5
 * Requires PHP:      8.0
 * Author:            SoftUni
 * Author URI:        https://softuni.bg
 * License:           GPL v2 or later
 * License URI:       https://www.gnu.org/licenses/gpl-2.0.html
 * Text Domain:       softuni-jobs
 * Domain Path:       /languages
 */

// Load Custom Post Types
require 'cpt-jobs.php';

// Load our basic functions
include 'functions.php';

// var_dump( 'test from plugin' );