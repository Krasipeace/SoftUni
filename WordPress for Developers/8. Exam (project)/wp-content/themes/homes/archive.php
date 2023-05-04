<?php get_header(); ?>

<?php the_archive_title() ?>

<?php if ( have_posts() ) : ?>

		<ul class="properties-listing">

            <?php while ( have_posts() ) : ?>
                <?php the_post(); ?>

                <?php get_template_part( 'template-parts/post', 'item' ); ?>

            <?php endwhile ?>

		</ul>

        <?php echo posts_nav_link(); ?>
        
    <?php endif ?>
		
<?php get_footer(); ?>