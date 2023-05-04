<?php get_header(); ?>

    <h1><?php the_archive_title(); ?></h1>

    <?php ?>
        <div>
            <p><?php ( the_author_meta( 'user_description' ) ); ?></p>
        </div>
    <?php ?>

    <?php if ( have_posts() ) : ?>

        <ul class="jobs-listing">
            <?php while ( have_posts() ) : ?>

                <?php the_post(); ?>

                <?php get_template_part( '/template-parts/home', 'item' ); ?>

            <?php endwhile ?>
        </ul>

        <?php echo posts_nav_link(); ?>
        
    <?php else : ?>

        <h3><?php ( 'This author has no posts' )?></h3>

    <?php endif ?>


<?php get_footer(); ?>