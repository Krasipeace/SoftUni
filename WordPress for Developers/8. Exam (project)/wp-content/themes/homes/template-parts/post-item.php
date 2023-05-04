<li class="property-card">
    <div class="property-primary">
        <h2 class="property-title">
            <a href="<?php the_permalink(); ?>"><?php the_title(); ?></a>
        </h2>
        <div class="property-meta">
            <a class="meta-category"><?php the_category(); ?></a>
            <span class="meta-date"><?php the_date(); ?></span>
        </div>
    </div>
    <div class="property-logo">
        <div class="property-logo-box">
            <?php
            if ( has_post_thumbnail() ) {
                the_post_thumbnail();
            } else {
                echo '<img src="http://localhost/wpexam/wp-content/themes/homes/assets/images/bedroom.jpg" alt="default thumbnail">';
            }
            ?>
        </div>
        <a id="<?php echo get_the_ID(); ?>" class="like-button" href="#">Like (<?php echo get_post_meta( get_the_ID(), 'likes', true ) ?>)</a>
    </div>
</li>