<?php get_header(); ?>

<?php if ( have_posts() ) : ?>
	<h2>Latest posts</h2>
	<ul class="jobs-listing">
		<?php while ( have_posts() ) : ?>

			<?php the_post(); ?>

			<?php get_template_part( 'partials/content', 'home' ); ?>

		<?php endwhile; ?>
	</ul>
<?php endif; ?>

<?php get_footer(); ?>