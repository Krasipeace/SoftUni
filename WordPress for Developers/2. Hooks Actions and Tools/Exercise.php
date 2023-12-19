<?php 
/* Plugin Name: Exercise
 * Description: Exercise
 * Version: 1.0
 */

 // 1. Check if user is admin

if ( is_admin() ) {
    var_dump( 'is_admin' );
} else {
    var_dump( 'is not admin' );
}

// 2. highest priority of execution = lowest number in filter

function change_title_test ( $title ) {
    return $title . ' 1st function';
}
add_filter ( 'the_title', 'change_title_1st_function', 10);

function change_title_again ( $title ) {
    return $title . ' 2nd function ';
}
add_filter ( 'the_title', 'change_title_2nd_function', 5 );

function change_title_3rd_function ( $title ) {
    return $title . ' 3rd function ';
}
add_filter ( 'the_title', 'change_title_3rd_function', 3 );

// 3. Add Twitter sharing button to the_content

function display_twitter_share ( $content ) {

    $post_title = get_the_title( get_the_ID() );
    //var dump ( $post_title ); die(); //-> check if it works

    $twitter = '<a class="twitter-share-button" href="https://twitter.com/intent/tweet?text='.$post_title.'">Tweet it!</a>';

    $content .= '<div>'. $twitter .'</div>';

    return $content;;
}
add_filter ( 'the_content', 'display_twitter_share' );

// 4. Add class to <body> tag

function add_class_to_body ( $classes ) {
    
    //var_dump( $classes ); die(); //-> check if it works

    $classes[] = 'my_custom_body_class';

    return $classes;
}
add_filter ( 'body_class', 'add_class_to_body' );

// 5. simple detect for word in content 

function detect_word ( $content ) {

    $word = 'standard';

    if ( str_contains( $content, $word ) ) {
        $content .= '<p>Word found!</p>';

    } else {
        $content .= '<p>Word not found!</p>';
    }

    return $content;
}
add_filter ( 'the_content', 'detect_word' );