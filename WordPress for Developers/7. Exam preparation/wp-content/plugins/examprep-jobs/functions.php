nes (22 sloc) 542 Bytes
<?php

/**
 * This functions update the jobs post meta for the views count
 *
 * @param [type] $job_id
 * @return void
 */
function examprep_update_job_views_count( $job_id ) {
    if ( empty( $job_id ) ) {
        return;
    }
    // if ( ! is_single( 'job' ) ) {
    //     return;
    // }

    $view_count = get_post_meta( $job_id, 'views_count', true );

    if ( ! empty( $view_count ) ) {
        $view_count = $view_count + 1;
    } else {
        $view_count = 1;
    }
    update_post_meta( $job_id, 'views_count', $view_count );

}