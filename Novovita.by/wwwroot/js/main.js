"use strict";

function owlCarouselActivation() {
    if ($(".banner-carousel").length) {
        $(".banner-carousel").owlCarousel({
            autoplay: true,
            autoplayTimeout: 8000,
            loop: true,
            animateOut: "fadeOut",
            pagination: true,
            mouseDrag: false,
            pullDrag: false,
            freeDrag: false,
            touchDrag: false,
            margin: 0,
            stagePadding: 0,
            smartSpeed: 1000,
            dotsEach: true,
            nav: false,
            items: 1
        })
    }
    if ($(".brand-carousel").length) {
        $(".brand-carousel").owlCarousel({
            autoplay: true,
            autoplayTimeout: 8000,
            loop: true,
            pagination: false,
            mouseDrag: true,
            pullDrag: true,
            freeDrag: true,
            touchDrag: true,
            margin: 0,
            stagePadding: 0,
            smartSpeed: 1000,
            nav: false,
            items: 5,
            responsive: {
                0 : {
                    items: 1
                },
                360 : {
                    items: 1
                },
                450 : {
                    items: 2
                },
                767 : {
                    items: 3
                },
                991 : {
                    items: 4
                },
                1200 : {
                    items: 5
                }
            }
        })
    }
    if ($(".testimonial").length) {
        $(".testimonial").owlCarousel({
            autoplay: true,
            autoplayTimeout: 8000,
            loop: true,
            pagination: true,
            touchDrag: true,
            margin: 0,
            stagePadding: 0,
            smartSpeed: 1000,
            nav: false,
            dotsEach: true,
            items: 1
        })
    }
    if ($(".blog-post").length) {
        $(".blog-post").owlCarousel({
            autoplay: true,
            autoplayTimeout: 8000,
            loop: true,
            pagination: true,
            touchDrag: true,
            margin: 30,
            stagePadding: 0,
            smartSpeed: 500,
            nav: true,
            dotsEach: false,
            items: 3,
            responsive: {
                0 : {
                    margin: 15,
                    autoWidth:false,
                    center: true,
                    nav: true,
                    navElement: "span",
                    navText: ["<span class='fa fa-angle-left'></span>","<span class='fa fa-angle-right'></span>"],
                    items: 1
                },
                372 : {
                    margin: 30,
                    autoWidth:true,
                    center: false,
                    nav: true,
                    navElement: "span",
                    navText: ["<span class='fa fa-angle-left'></span>","<span class='fa fa-angle-right'></span>"],
                    items: 1
                },
                470 : {
                    margin: 30,
                    autoWidth:true,
                    center: false,
                    nav: true,
                    navElement: "span",
                    navText: ["<span class='fa fa-angle-left'></span>","<span class='fa fa-angle-right'></span>"],
                    items: 1
                },
                471 : {
                    margin: 30,
                    autoWidth:true,
                    center: false,
                    nav: false,
                    items: 1
                },
                500 : {
                    margin: 30,
                    autoWidth:true,
                    center: false,
                    nav: false,
                    items: 1
                },
                991 : {
                    autoWidth:true,
                    items: 2,
                    nav: false
                },
                1000 : {
                    items: 2,
                    nav: false,
                    autoWidth:true
                },
                1100 : {
                    margin: 15,
                    nav: false,
                    autoWidth:true
                }
            }
        })
    }
    if ($(".gallery-carousel").length) {
        $(".gallery-carousel").owlCarousel({
            autoplay: true,
            autoplayTimeout: 8000,
            loop: true,
            pagination: true,
            touchDrag: true,
            margin: 30,
            stagePadding: 46,
            smartSpeed: 500,
            nav: false,
            dotsEach: false,
            rtl: true,
            items: 1,
            responsive: {
                420 : {
                    items: 1
                },
                421 : {
                    items: 2
                },
                767 : {
                    items: 2
                },
                768 : {
                    items: 3,
                    autoWidth:false
                },
                1199 : {
                    items: 3
                },
                1200 : {
                    items: 2
                },
                1700 : {
                    margin: 50,
                    autoWidth:true,
                    items: 2
                }
            }
        })
    }
}

function popupImage() {
    $('.popupGallery').each(function() {
        $(this).magnificPopup({
            delegate: 'a',
            type: 'image',
            gallery: {
                enabled:true,
                preload: [0,2],
                navigateByImgClick: true,
                arrowMarkup: '<button title="%title%" type="button" class="mfp-arrow mfp-arrow-%dir%"></button>',
                tPrev: 'Previous (Left arrow key)',
                tNext: 'Next (Right arrow key)',
                tCounter: '<span class="mfp-counter">%curr% of %total%</span>'
            },
            zoom: {
                enabled: true,
                duration: 300,
                easing: 'ease-in-out',
                opener: function(openerElement) {
                  return openerElement.is('img') ? openerElement : openerElement.find('img');
                }
            }
        });
    });
}

function mobileNavToggle () {
    if ($('#main-menu .navbar-nav .sub-menu').length) {
        var subMenu = $('#main-menu .navbar-nav .sub-menu');
        subMenu.parent('li').children('a').append(function () {
            return '<button class="sub-nav-toggler"> <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span> <span class="icon-bar"></span> <span class="icon-bar"></span> </button>';
        });
        var subNavToggler = $('#main-menu .navbar-nav .sub-nav-toggler');
        subNavToggler.on('click', function () {
            var Self = $(this);
            Self.parent().parent().children('.sub-menu').slideToggle();
            return false;
        });
    };
}

function galleryMasonaryLayout() {
    if ($('.masonary-layout').length) {
        $('.masonary-layout').isotope({
            layoutMode: 'masonry'
        });
    }

    if ($('.post-filter').length) {
        var postFilterList = $('.post-filter li');
        postFilterList.children('span').on('click', function() {
            var Self = $(this);
            var selector = Self.parent().attr('data-filter');
            postFilterList.children('span').parent().removeClass('active');
            Self.parent().addClass('active');


            $('.filter-layout').isotope({
                filter: selector,
                animationOptions: {
                    duration: 500,
                    easing: 'linear',
                    queue: false
                }
            });
            return false;
        });
    }
}


function eventTime() {
    if ($("#timer").length) {
        $('#timer').countdown({
            date: '11/11/2018'
        });
    }
}

function backToTop() {
    if ($(".back2Top").length) {
        $(".back2Top").on("click", function() {
            $("html, body").animate({
                scrollTop: 0
            }, 500)
        })
    }
}

function backToTopVisible() {
    if ($(".back2Top").length) {
        if ($(window).scrollTop() > 150) {
            $(".back2Top").addClass("totop")
        } else {
            $(".back2Top").removeClass("totop")
        }
    }
}

function fixedNav() {
    if ($(".nav-fixed, .nav-solid").length) {
        if ($(window).scrollTop() > 120) {
            $(".nav-fixed, .nav-solid").addClass("fixed-nav")
        } else {
            $(".nav-fixed, .nav-solid").removeClass("fixed-nav")
        }
    }
}

function handlePreloader() {
    if($('.preloader').length){
        $('.preloader').fadeOut();
    }
}

jQuery(document).on("ready", function() {
    (function(a) {
        backToTop();
        owlCarouselActivation();
        mobileNavToggle();
        eventTime();
        popupImage();

        var $navi = $(".nav-fixed, .nav-solid"), scrollTop = 0;
          $(window).scroll(function () {
            var y = $(this).scrollTop(), speed = 0.05, pos = y * speed, maxPos = 110;
            if (y > scrollTop) {
              pos = maxPos;
            } else {
              pos = 0;
            }
            scrollTop = y;
            $navi.css({
              "-webkit-transform": "translateY(-" + pos + "%)",
              "-moz-transform": "translateY(-" + pos + "%)",
              "-o-transform": "translateY(-" + pos + "%)",
              "transform": "translateY(-" + pos + "%)"
            });
          });
    })(jQuery)
});
jQuery(window).on("scroll", function() {
    (function(a) {
        backToTopVisible();
        fixedNav();
    })(jQuery)
});

// instance of fuction while Window Load event
jQuery(window).on('load', function() {
    (function($) {
        galleryMasonaryLayout();
        handlePreloader();
    })(jQuery);
});

$(window).enllax();