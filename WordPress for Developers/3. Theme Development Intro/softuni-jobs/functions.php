<?php 

add_theme_support( 'post-thumbnails' );

add_image_size ( 'job-thumbnail', 105, 120 );

function softuni_assests() {
    wp_enqueue_style( 'softuni-jobs', get_template_directory_uri() . 'css/master.css' );
}
add_action( 'wp enqueue scripts', 'softuni assests');