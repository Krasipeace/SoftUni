<?php

/**
 * This functions update view count for a property
 *
 * @param [type] property_id
 * @return void
 */
function softuni_update_home_views_count( $property_id ) {
    if ( empty( $property_id ) ) {
        return;
    }

    $view_count = get_post_meta( $property_id, 'views_count', true );

    if ( ! empty( $view_count ) ) {
        $view_count = $view_count + 1;
    } else {
        $view_count = 1;
    }

    update_post_meta( $property_id, 'views_count', $view_count );
}

/**
 * Functions takes care of the like of the property
 *
 * @return void
 */
function softuni_property_like() {
	$job_id = esc_attr( $_POST['job_id'] );

	$like_number = get_post_meta( $job_id, 'likes', true );

    if ( empty( $like_number ) ) {
        update_post_meta( $job_id, 'likes', 1 );
    } else {
        $like_number = $like_number + 1;
        update_post_meta( $job_id, 'likes', $like_number );
    }

    wp_die();
}
add_action( 'wp_ajax_nopriv_softuni_property_like', 'softuni_property_like' );
add_action( 'wp_ajax_softuni_property_like', 'softuni_property_like' );