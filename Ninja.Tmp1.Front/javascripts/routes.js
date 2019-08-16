(function ($) {

  var app = $.sammy('#main', function () {
    this.use('Template');

    this.get('#/', function (context) {
      context.app.swap('');
    });

    this.get('#/', function (context) {
      context.app.swap('');
      context.render('templates/users/connexion.html', { id: i, item: item }).appendTo(context.$element());
    });
  });

  $(function () {
    app.run('#/');
  });

})(jQuery);
