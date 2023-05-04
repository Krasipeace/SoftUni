<?php

/**
 * Register a custom post type "property".
 *
 * @see get_post_type_labels() for label keys.
 */
function softuni_homes_property_cpt() {
	$labels = array(
		'name'                  => _x( 'Properties', 'Post type general name', 'homes' ),
		'singular_name'         => _x( 'Property', 'Post type singular name', 'homes' ),
		'menu_name'             => _x( 'Properties (homes)', 'Admin Menu text', 'homes' ),
		'name_admin_bar'        => _x( 'Property', 'Add New on Toolbar', 'homes' ),
		'add_new'               => __( 'Add New', 'homes' ),
		'add_new_item'          => __( 'Add New Property', 'homes' ),
		'new_item'              => __( 'New Property', 'homes' ),
		'edit_item'             => __( 'Edit Property', 'homes' ),
		'view_item'             => __( 'View Property', 'homes' ),
		'all_items'             => __( 'All Properties', 'homes' ),
	);

	$args = array(
		'labels'             => $labels,
		'public'             => true,
		'publicly_queryable' => true,
		'show_ui'            => true,
		'show_in_menu'       => true,
		'query_var'          => true,
		'rewrite'            => array( 'slug' => 'property' ),
		'capability_type'    => 'post',
		'has_archive'        => true,
		'hierarchical'       => false,
		'menu_position'      => null,
		'supports'           => array( 'title', 'editor', 'custom-fields', 'author', 'thumbnail', 'excerpt', 'revisions' ),
        'show_in_rest'       => true,
	);

	register_post_type( 'property', $args );
}
add_action( 'init', 'homes_property_cpt' );

/**
 * Register a 'field' taxonomy for post type 'property', with a rewrite to match book CPT slug.
 *
 * @see register_post_type for registering post types.
 */
function softuni_homes_property_taxonomy() {
    $labels = array(
		'name'              => _x( 'Field', 'taxonomy general name', 'homes' ),
		'singular_name'     => _x( 'Field', 'taxonomy singular name', 'homes' ),
		'search_items'      => __( 'Search Field', 'homes' ),
		'all_items'         => __( 'All Field', 'homes' ),
		'parent_item'       => __( 'Parent Field', 'homes' ),
		'parent_item_colon' => __( 'Parent Field:', 'homes' ),
		'edit_item'         => __( 'Edit Field', 'homes' ),
		'update_item'       => __( 'Update Field', 'homes' ),
		'add_new_item'      => __( 'Add New Field', 'homes' ),
		'new_item_name'     => __( 'New Field Name', 'homes' ),
		'menu_name'         => __( 'Field', 'homes' ),
	);

    $args = array(
		'hierarchical'      => true,
		'labels'            => $labels,
		'show_ui'           => true,
		'show_admin_column' => true,
		'query_var'         => true,
        'show_in_rest'      => true
	);


    register_taxonomy( 'field', 'job', $args );
}
add_action( 'init', 'softuni_homes_field_taxonomy' );

/**
 * This is a function registering a custom Job Location taxonomy
 *
 * @return void
 */
function softuni_homes_location_taxonomy() {
    $labels = array(
		'name'              => _x( 'Location', 'taxonomy general name', 'homes' ),
		'singular_name'     => _x( 'Location', 'taxonomy singular name', 'homes' ),
		'search_items'      => __( 'Search Locations', 'homes' ),
		'all_items'         => __( 'All Locations', 'homes' ),
		'parent_item'       => __( 'Parent Location', 'homes' ),
		'parent_item_colon' => __( 'Parent Location:', 'homes' ),
		'edit_item'         => __( 'Edit Location', 'homes' ),
		'update_item'       => __( 'Update Locations', 'homes' ),
		'add_new_item'      => __( 'Add New Location', 'homes' ),
		'new_item_name'     => __( 'New Location Name', 'homes' ),
		'menu_name'         => __( 'Location', 'homes' ),
	);

    $args = array(
		'hierarchical'      => true,
		'labels'            => $labels,
		'show_ui'           => true,
		'show_admin_column' => true,
		'query_var'         => true,
        'show_in_rest'      => true
	);

    register_taxonomy( 'location', 'job', $args );
}
add_action( 'init', 'softuni_homes_location_taxonomy' );