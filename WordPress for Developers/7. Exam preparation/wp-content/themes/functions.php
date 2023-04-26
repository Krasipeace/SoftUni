<?php

/**
 * This function takes care of handling the assets with enqueue
 *
 * @return void
 */

function examprep_assets() {
    wp_enqueue_style( 'examprep-jobs', get_stylesheet_directory_uri() . '/assets/css/master.css', array(), filemtime(  get_template_directory() . '/assets/css/master.css' ) );
}
add_action( 'wp_enqueue_scripts', 'examprep_assets' );

/**
 * This function add a custom class
 *
 * @return void
 */
function examprep_body_class( $classes ) {
    $classes[] = 'test-class';

    return $classes;
}
add_filter( 'body_class', 'examprep_body_class' );