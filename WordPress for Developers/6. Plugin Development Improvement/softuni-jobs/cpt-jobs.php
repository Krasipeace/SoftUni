<?php
/**
 * Register a custom post type called "job".
 *
 * @see get_post_type_labels() for label keys.
 */
function softuni_jobs_cpt() {
	$labels = array(
		'name'                  => _x( 'Jobs', 'Post type general name', 'softuni' ),
		'singular_name'         => _x( 'Job', 'Post type singular name', 'softuni' ),
		'menu_name'             => _x( 'Jobs', 'Admin Menu text', 'softuni' ),
		'name_admin_bar'        => _x( 'Job', 'Add New on Toolbar', 'softuni' ),
		'add_new'               => __( 'Add New', 'softuni' ),
		'add_new_item'          => __( 'Add New Job', 'softuni' ),
		'new_item'              => __( 'New Job', 'softuni' ),
		'edit_item'             => __( 'Edit Job', 'softuni' ),
		'view_item'             => __( 'View Job', 'softuni' ),
		'all_items'             => __( 'All Jobs', 'softuni' ),
	);

	$args = array(
		'labels'             => $labels,
		'public'             => true,
		'publicly_queryable' => true,
		'show_ui'            => true,
		'show_in_menu'       => true,
		'query_var'          => true,
		'rewrite'            => array( 'slug' => 'job' ),
		'capability_type'    => 'post',
		'has_archive'        => true,
		'hierarchical'       => false,
		'menu_position'      => null,
		'supports'           => array( 'title', 'editor', 'author', 'thumbnail', 'excerpt', 'revisions' ),
        'show_in_rest'       => true
	);

	register_post_type( 'job', $args );

    // flush_rewrite_rules(); // refresh permalinks on every load
}
add_action( 'init', 'softuni_jobs_cpt' );

/**
 * Register a 'field' taxonomy for post type 'job', with a rewrite to match book CPT slug.
 *
 * @see register_post_type for registering post types.
 */
function softuni_jobs_field_taxonomy() {
    $labels = array(
		'name'              => _x( 'Field', 'taxonomy general name', 'softuni' ),
		'singular_name'     => _x( 'Field', 'taxonomy singular name', 'softuni' ),
		'search_items'      => __( 'Search Field', 'softuni' ),
		'all_items'         => __( 'All Field', 'softuni' ),
		'parent_item'       => __( 'Parent Field', 'softuni' ),
		'parent_item_colon' => __( 'Parent Field:', 'softuni' ),
		'edit_item'         => __( 'Edit Field', 'softuni' ),
		'update_item'       => __( 'Update Field', 'softuni' ),
		'add_new_item'      => __( 'Add New Field', 'softuni' ),
		'new_item_name'     => __( 'New Field Name', 'softuni' ),
		'menu_name'         => __( 'Field', 'softuni' ),
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
add_action( 'init', 'softuni_jobs_field_taxonomy' );

/**
 * This is a function registering a custom Job Location taxonomy
 *
 * @return void
 */
function softuni_jobs_location_taxonomy() {
    $labels = array(
		'name'              => _x( 'Location', 'taxonomy general name', 'softuni' ),
		'singular_name'     => _x( 'Location', 'taxonomy singular name', 'softuni' ),
		'search_items'      => __( 'Search Locations', 'softuni' ),
		'all_items'         => __( 'All Locations', 'softuni' ),
		'parent_item'       => __( 'Parent Location', 'softuni' ),
		'parent_item_colon' => __( 'Parent Location:', 'softuni' ),
		'edit_item'         => __( 'Edit Location', 'softuni' ),
		'update_item'       => __( 'Update Locations', 'softuni' ),
		'add_new_item'      => __( 'Add New Location', 'softuni' ),
		'new_item_name'     => __( 'New Location Name', 'softuni' ),
		'menu_name'         => __( 'Location', 'softuni' ),
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
add_action( 'init', 'softuni_jobs_location_taxonomy' );

/**
 * This is a function registering a custom Job Company taxonomy
 *
 * @return void
 */
function softuni_jobs_company_taxonomy() {
    $labels = array(
		'name'              => _x( 'Company', 'taxonomy general name', 'softuni' ),
		'singular_name'     => _x( 'Company', 'taxonomy singular name', 'softuni' ),
		'search_items'      => __( 'Search Companies', 'softuni' ),
		'all_items'         => __( 'All Companies', 'softuni' ),
		'parent_item'       => __( 'Parent Company', 'softuni' ),
		'parent_item_colon' => __( 'Parent Company:', 'softuni' ),
		'edit_item'         => __( 'Edit Company', 'softuni' ),
		'update_item'       => __( 'Update Companies', 'softuni' ),
		'add_new_item'      => __( 'Add New Company', 'softuni' ),
		'new_item_name'     => __( 'New Company Name', 'softuni' ),
		'menu_name'         => __( 'Company', 'softuni' ),
	);

    $args = array(
		'hierarchical'      => false,
		'labels'            => $labels,
		'show_ui'           => true,
		'show_admin_column' => true,
		'query_var'         => true,
        'show_in_rest'      => true
	);

    register_taxonomy( 'company', 'job', $args );
}
add_action( 'init', 'softuni_jobs_company_taxonomy' );