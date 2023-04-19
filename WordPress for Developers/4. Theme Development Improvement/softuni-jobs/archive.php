<?php get_header(); ?>

<h1><?php the_archive_title(); ?></h1>

<?php if ( have_posts() ) : ?>
	<ul class="jobs-listing">
		<?php while ( have_posts() ) : ?>

			<?php the_post(); ?>

			<?php get_template_part( 'partials/content', 'archive' ); ?>

		<?php endwhile; ?>
	</ul>

<?php else : ?>

    <?php _e( 'Not found posts', 'softuni' ); ?>

<?php endif; ?>

<?php get_footer(); ?>