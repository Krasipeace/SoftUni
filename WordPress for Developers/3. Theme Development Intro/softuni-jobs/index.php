<?php get_header(); ?>

<main class="site-main">
	<section class="section-fullwidth section-jobs-preview">
		<div class="row">	
			<?php if (have_posts() ) : ?>
				<h3>Latest Posts</h2>
				<ul class="jobs-listing">
					<?php while ( have_posts() ) : ?>
						<?php the_post(); ?>

						<li class="job-card">
							<div class="job-primary">
								<h2 class="job-title"><a href="<?php the_permalink(); ?>"><?php the_title(); ?></a></h2>
								<div class="job-meta">
									<a class="meta-company" href="#">Company Awesome Ltd.</a>
									<span class="meta-date">Posted on <?php echo get_the_date(); ?></span>
								</div>
								<div class="job-details">
									<span class="job-location">The Hague (The Netherlands)</span>
									<span class="job-type">Contract staff</span>
								</div>
							</div>
							
							<div>
								<div class="job-logo-box">
									<?php if ( has_post_thumbnail() ) : ?>
									<?php the_post_thumbnail( 'job-thumbnail' ); ?>
								</div>
								<?php else : ?>
								<div class="job-logo-box">
									<img src="https://i.imgur.com/ZbILm3F.png" alt="default_image">
								</div>
								<?php endif; ?>
							</div>
						</li>						

					<?php endwhile; ?>
				</ul>
			<?php endif; ?>

		</div>
	</section>	
</main>

<?php get_footer(); ?>