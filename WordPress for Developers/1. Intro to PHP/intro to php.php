<?php
echo 'Hello, world';
echo '<br / >';

$var = 'test'; //declare 
$another_var = 'test2'; # second variable
echo $var;  /* call */

var_dump( $var);  

//die(); //stops executing of the code after command.. good for code debugging

// Conditional statements
$a = 1;
$b = 2;

if ( $a == $b) {
    echo 'a = b';
} else if ( $a < $b ) {
    echo 'a < b';
} else {
    echo 'a > b';
}

$array = array (
    'one',
    'two',
    'three',
    4,
    9.5
);

var_dump ( count ( $array ) ); // => count elements of array

var_dump ( $array ); //print the array

foreach( $array as $item) {
    echo $item . '<br />'; //print each element  of the array on new line 
}

for ($i=0; $i<=5 ; $i++) { 
    echo $i;
}

// kvp array
$array2 = array (
    1=>'one',
    2=>'two',
    3=>'three'
);

foreach( $array2 as $key => $item ) {
    echo $key . ' > ' . $item . '<br />';
}

function my_first_function() {
    return 'hi from the function';
}

$var2 = my_first_function();
echo $var2;

$x = 1;
$y = 2;

function my_second_function( $x, $y ) {
    //soft data validation
    if ( ! empty($x) && ! empty($y)) {
        return;
    }

    if ( $x == $y ) {
        echo 'x = y';
    } elseif ( $x > $y ) {
        echo 'x > y';
    } else {
        echo 'x < y';
    }
}

my_second_function( $x, $y );
my_second_function( 4, 3) ;

// function will convert length of first argument 'test' to number, in this case length = 4 => 4 > 3 
my_second_function( 'test', 3 );

//php OOP
class Fruit {
    public $name;
    public $color;

    function set_name($name) {
        $this->name = $name; 
    }
    function get_name() {
        return $this-> name;
    }
}