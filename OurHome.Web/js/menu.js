//Управление боковым меню
$(document).ready(function () {
    var menu_open = false;

    var side_menu = $('.side-menu');
    var darker = $('.menu-darker');

    $('.side-menu-button').click(function() {
        toggleMenu();
    });

    $('.menu-darker').click(function () {
        toggleMenu();
    });

    function toggleMenu() {
        menu_open = !menu_open;

        if (menu_open) {
            side_menu.css('margin-left', '0');
            darker.css('display', 'block');
            $('body').css('overflow', 'hidden');
        } else {
            side_menu.css('margin-left', '-350px');
            darker.css('display', 'none');
            $('body').css('overflow', 'auto');
        }
    }
})