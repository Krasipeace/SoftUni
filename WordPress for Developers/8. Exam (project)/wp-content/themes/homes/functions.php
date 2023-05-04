<?php

/**
 * This function takes care of handling the assets with enqueue
 *
 * @return void
 */
function homes_assets() {
    wp_enqueue_style( 'homes', get_stylesheet_directory_uri() . '/assets/css/master.css', array(), filemtime(  get_template_directory() . '/assets/css/master.css' ) );
}
add_action( 'wp_enqueue_scripts', 'homes_assets' );

/**
 * This function add a custom class
 *
 * @return void
 */
function homes_body_class( $classes ) {
    $classes[] = 'test-class';

    return $classes;
}
add_filter( 'body_class', 'homes_body_class' );

/**
 * Custome Menu
 *
 * @return void
 */
function homes_register_nav_menu(){
    register_nav_menus( array(
        'primary_menu' => __( 'Primary Menu Name', 'homes' ),
        'footer_menu'  => __( 'Footer Menu', 'homes' ),
    ) );
}
add_action( 'after_setup_theme', 'homes_register_nav_menu', 0 );

