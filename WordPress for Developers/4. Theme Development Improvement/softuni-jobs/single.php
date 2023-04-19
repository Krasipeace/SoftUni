<?php get_header(); ?>

<?php if ( have_posts() ) : ?>

	<?php while( have_posts() ) : ?>

		<?php the_post(); ?>

		<div class="job-single">
			<main class="job-main">
				<div class="job-card">
					<div class="job-primary">
						<header class="job-header">
							<h1 class="job-title"><a href="<?php the_permalink(); ?>"><?php the_title(); ?></a></h1>
							<div class="job-meta">
								<a class="meta-company" href="#">Company Awesome Ltd.</a>
								<span class="meta-date">Posted on <?php echo get_the_date(); ?></span>
							</div>
							<div class="job-details">
								<span class="job-location">The Hague (The Netherlands)</span>
								<span class="job-type"><?php the_author(); ?></span>
							</div>
						</header>

						<div class="job-body">
							<?php the_content(); ?>
						</div>
					</div>
				</div>
			</main>
			<aside class="job-secondary">
				<div class="job-logo">
					<div class="job-logo-box">
						<?php if ( has_post_thumbnail() ) :  ?>
							<?php the_post_thumbnail( 'job-thumbnail' ); ?>
						<?php else : ?>
							<img src="https://i.imgur.com/ZbILm3F.png" alt="default image">
						<?php endif; ?>
					</div>
				</div>
				<a href="#" class="button button-wide">Apply now</a>
				<a href="#">apple.com</a>
			</aside>
		</div>

		<h2 class="section-heading">Other related jobs:</h2>
		<ul class="jobs-listing">
			<li class="job-card">
				<div class="job-primary">
					<h2 class="job-title"><a href="#">Front End Developer</a></h2>
					<div class="job-meta">
						<a class="meta-company" href="#">Company Awesome Ltd.</a>
						<span class="meta-date">Posted 14 days ago</span>
					</div>
					<div class="job-details">
						<span class="job-location">The Hague (The Netherlands)</span>
						<span class="job-type">Contract staff</span>
					</div>
				</div>
				<div class="job-logo">
					<div class="job-logo-box">
						<img src="https://i.imgur.com/ZbILm3F.png" alt="">
					</div>
				</div>
			</li>

			<li class="job-card">
				<div class="job-primary">
					<h2 class="job-title"><a href="#">Front End Developer</a></h2>
					<div class="job-meta">
						<a class="meta-company" href="#">Company Awesome Ltd.</a>
						<span class="meta-date">Posted 14 days ago</span>
					</div>
					<div class="job-details">
						<span class="job-location">The Hague (The Netherlands)</span>
						<span class="job-type">Contract staff</span>
					</div>
				</div>
				<div class="job-logo">
					<div class="job-logo-box">
						<img src="https://i.imgur.com/ZbILm3F.png" alt="">
					</div>
				</div>
			</li>
		</ul>

	<?php endwhile; ?>

<?php endif; ?>

<?php get_footer();