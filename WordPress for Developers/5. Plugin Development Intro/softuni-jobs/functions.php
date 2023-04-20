<?php 

/**
 * Display a single post term
 *
 * @param integer $post_id
 * @param [type] $taxonomy
 * @return void
 */
function softuni_display_single_term( $post_id, $taxonomy ) {

    if ( empty( $post_id ) || empty( $taxonomy ) ) {
        return;
    }

    $terms = get_the_terms( $post_id, $taxonomy );

    $output = '';
    if ( ! empty( $terms ) && is_array( $terms ) ) {
        foreach( $terms as $term ) {
            $output .= $term->name . ', ' ;
        }
    }

    return $output;
}

/**
 * Display other jobs per company
 *
 * @param integer $job_id
 * @return void
 */
function softuni_display_other_jobs_per_company( $job_id ) {
    if ( empty( $job_id ) ) {
        return;
    }

    $jobs_args = array(
        'post_type'         => 'job',
        'post_status'       => 'publish',
        'orderby'           => 'name',
        'posts_per_page'    => 2,

        // set a taxonomy query
    );

    $jobs_query = new WP_Query( $jobs_args );

    // var_dump( $jobs_query ); die();

    if ( ! empty( $jobs_query ) ) {
        ?>
        <ul class="jobs-listing">
            <?php foreach( $jobs_query->posts as $job ) { ?>

                <?php // var_dump( $job ); ?>
                <li class="job-card">
                    <div class="job-primary">
                        <h2 class="job-title"><a href="#"><?php echo $job->post_title; ?></a></h2>
                        <div class="job-meta">
                            <a class="meta-company" href="#">Company Awesome Ltd.</a>
                            <span class="meta-date">Posted 14 days ago</span>
                        </div>
                        <div class="job-details">
                            <span class="job-location">The Hague (The Netherlands)</span>
                            <span class="job-type">Contract staff</span>
                        </div>
                    </div>
                    <div class="job-logo">
                        <div class="job-logo-box">
                            <img src="https://i.imgur.com/ZbILm3F.png" alt="">
                        </div>
                    </div>
                </li>
            <?php } ?>
		</ul>
    <?php
    }
}
