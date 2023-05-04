<?php get_header(); ?>

<?php echo get_search_form(); ?>

<?php if ( have_posts() ) : ?>
	<h2>Results</h2>
	<ul class="jobs-listing">
		<?php while ( have_posts() ) : ?>

			<?php the_post(); ?>
            
            <?php get_template_part( '/template-parts/home', 'item' ); ?>

		<?php endwhile; ?>
	</ul>
<?php endif; ?>

<?php get_footer(); ?>