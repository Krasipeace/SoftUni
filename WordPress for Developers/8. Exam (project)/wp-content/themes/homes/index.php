<?php get_header(); ?>

<ul class="properties-listing">
	<?php if ( have_posts() ) : ?>

		<?php while ( have_posts() ) : the_post(); ?>

			<?php get_template_part( 'template-parts/home', 'item' ); ?>

		<?php endwhile; ?>

		<?php echo posts_nav_link(); ?>

	<?php endif; ?>
</ul>
		
<?php get_footer(); ?>