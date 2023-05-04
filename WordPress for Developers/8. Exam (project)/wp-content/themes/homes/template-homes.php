<?php
/* Template Name: Display Homes */
?>

<?php get_header(); ?>

<?php
$property_args = array(
	'post_type'			=> 'property',
	'post_status'		=> 'publish',
	'orderby'			=> 'date',
	'order'				=> 'ASC',
);

$properties_query = new WP_Query( $properties_args );
?>

<?php
if ( have_posts() ) {
	while ( have_posts() ) {
		the_post();

		the_content();
	}
}
?>

<ul class="properties-listing">
	<?php if ( $properties_query->have_posts() ) : ?>

		<?php while( $properties_query->have_posts() ) : $properties_query->the_post(); ?>

			<?php get_template_part( 'template-parts/home', 'item' ); ?>

		<?php endwhile; ?>

		<?php posts_nav_link(); ?>

	<?php endif; ?>

	<?php wp_reset_postdata(); ?>
</ul>

<?php get_footer(); ?>