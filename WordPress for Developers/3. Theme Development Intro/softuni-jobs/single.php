<?php get_header(); ?>

<div class="job-single">
	<div class="job-main">
		<div class="job-card">
			<div class="job-primary">
				<header class="job-header">
					<h2 class="job-title"><a href="#">Front End Developer</a></h2>
					<div class="job-meta">
						<a class="meta-company" href="#">Company Awesome Ltd.</a>
						<span class="meta-date">Posted 14 days ago</span>
					</div>
					<div class="job-details">
						<span class="job-location">The Hague (The Netherlands)</span>
						<span class="job-type">Contract staff</span>
						<span class="job-price">1500лв.</span>
					</div>
				</header>

				<div class="job-body">
					<p>Our band of superheroes are looking for a self-driven, highly organised individual who will join the team in creating our most important products.</p>
					<p>Location is unimportant, as long as you are available, enthusiastic, committed, passionate, and know your stuff.</p>
					<p>For this role, we need a superhero who will take on the challenges of working in one of the leading WordPress companies, enhancing our website, products, and services, backed by a quality team of pros.</p>

					<h3>Responsibilities</h3>
					<p>You’ll be part of a development team working on our flagship products. It’s going to be epic!</p>
				</div>
			</div>
		</div>
	</div>
	<aside class="job-secondary">
		<div class="job-logo">
			<div class="job-logo-box">
				<img src="https://i.imgur.com/ZbILm3F.png" alt="">
			</div>
		</div>
		<a href="#" class="button button-wide">Apply now</a>
		<a href="#">apple.com</a>
	</aside>
</div>

<section class="section-fullwidth">
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
</section>	

<?php get_footer(); ?>