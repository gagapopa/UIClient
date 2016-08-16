/**
 * Copyright (c) 2011-2014 Felix Gnass
 * Licensed under the MIT license
 */

/*

Basic Usage:
============

$('#el').spin(); // Creates a default Spinner using the text color of #el.
$('#el').spin({ ... }); // Creates a Spinner using the provided options.

$('#el').spin(false); // Stops and removes the spinner.

Using Presets:
==============

$('#el').spin('small'); // Creates a 'small' Spinner using the text color of #el.
$('#el').spin('large', '#fff'); // Creates a 'large' white Spinner.

Adding a custom preset:
=======================

$.fn.spin.presets.flower = {
  lines: 9
  length: 10
  width: 20
  radius: 0
}

$('#el').spin('flower', 'red');

*/

( function ( factory ) {

    if ( typeof exports == 'object' ) {
        // CommonJS
        factory( require( 'jquery' ), require( 'spin' ) );
    }
    else if ( typeof define == 'function' && define.amd ) {
        // AMD, register as anonymous module
        define( ['jquery', 'spin'], factory );
    }
    else {
        // Browser globals
        if ( !window.Spinner ) throw new Error( 'Spin.js not present' );
        factory( window.jQuery, window.Spinner );
    }

}( function ( $, Spinner ) {

    $.fn.spin = function ( opts, color ) {

        return this.each( function () {
            var $this = $( this ),
				data = $this.data();

            if ( data.spinner ) {
                $this.removeAttr( 'disabled' );
                data.spinner.stop();
                delete data.spinner;
            }
            if ( opts !== false ) {
                opts = $.extend( {}, $.fn.spin.presets['def'] || opts );
                //opts.left =	(($this.css('width').substring(0, $this.css('width').indexOf('px')) / 2) + 15) + 'px';

                data.spinner = new Spinner( opts ).spin( this );
                $this.attr( 'disabled', 'disabled' );
            }
        } );
    };

    $.fn.spin.presets = {
        def: {
            lines: 13,
            length: 3,
            width: 2,
            radius: 6,
            conrners: 1,
            rotate: 0,
            direction: 1,
            color: '#000',
            speed: 1,
            trail: 60,
            shadow: false,
            hwaccel: false,
            className: 'spinner',
            zIndex: 2e9,
            top: '8px',
            left: '50%'
        }
    };

} ) );
