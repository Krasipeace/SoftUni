<?php get_header(); ?>

<?php if ( have_posts() ) : ?>
	<h2>Results</h2>
	<ul class="jobs-listing">
		<?php while ( have_posts() ) : ?>

			<?php the_post(); ?>

			<li class="job-card">
				<div class="job-primary">
					<h2 class="job-title">
                        <a href="<?php the_permalink(); ?>"><?php the_title(); ?></a>
                    </h2>
					<div class="job-meta">
						<a class="meta-company" href="#">Company Awesome Ltd.</a>
						<span class="meta-date">Posted on <?php echo get_the_date(); ?></span>
					</div>
				</div>
				<div class="job-logo">
					<div class="job-logo-box">
					<?php if ( has_post_thumbnail() ) :  ?>
						<?php the_post_thumbnail( 'job-thumbnail' ); ?>
					<?php else : ?>
						<img src="https://i.imgur.com/ZbILm3F.png" alt="default image">
					<?php endif; ?>
					</div>
				</div>
			</li>

		<?php endwhile; ?>
	</ul>
<?php endif; ?>

<?php get_footer(); ?>