<?php
/**
 * Register a custom post type called "job".
 *
 * @see get_post_type_labels() for label keys.
 */
function examprep_jobs_cpt() {
	$labels = array(
		'name'                  => _x( 'Jobs', 'Post type general name', 'examprep' ),
		'singular_name'         => _x( 'Job', 'Post type singular name', 'examprep' ),
		'menu_name'             => _x( 'Jobs', 'Admin Menu text', 'examprep' ),
		'name_admin_bar'        => _x( 'Job', 'Add New on Toolbar', 'examprep' ),
		'add_new'               => __( 'Add New', 'examprep' ),
		'add_new_item'          => __( 'Add New Job', 'examprep' ),
		'new_item'              => __( 'New Job', 'examprep' ),
		'edit_item'             => __( 'Edit Job', 'examprep' ),
		'view_item'             => __( 'View Job', 'examprep' ),
		'all_items'             => __( 'All Jobs', 'examprep' ),
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

    flush_rewrite_rules();
}
add_action( 'init', 'examprep_jobs_cpt' );

/**
 * Register a 'field' taxonomy for post type 'job', with a rewrite to match book CPT slug.
 *
 * @see register_post_type for registering post types.
 */
function examprep_jobs_field_taxonomy() {
    $labels = array(
		'name'              => _x( 'Field', 'taxonomy general name', 'examprep' ),
		'singular_name'     => _x( 'Field', 'taxonomy singular name', 'examprep' ),
		'search_items'      => __( 'Search Field', 'examprep' ),
		'all_items'         => __( 'All Field', 'examprep' ),
		'parent_item'       => __( 'Parent Field', 'examprep' ),
		'parent_item_colon' => __( 'Parent Field:', 'examprep' ),
		'edit_item'         => __( 'Edit Field', 'examprep' ),
		'update_item'       => __( 'Update Field', 'examprep' ),
		'add_new_item'      => __( 'Add New Field', 'examprep' ),
		'new_item_name'     => __( 'New Field Name', 'examprep' ),
		'menu_name'         => __( 'Field', 'examprep' ),
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
add_action( 'init', 'examprep_jobs_field_taxonomy' );