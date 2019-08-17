(function ($) {

  var app = $.sammy('#main', function () {
    this.use('Template');

    this.get('#/', function (context) {
      context.app.swap('');
    });

    this.addPage = function (pageUrl, pageType) {
      this.get('#/' + pageUrl, function (context) {
        context.app.swap('');
        context.render('templates/' + pageUrl + '.html', {}).appendTo(context.$element()).then(function () {
          var page = new pageType();
          page.onInit();
        })
      });
    }
    addRoutes(this);

  });

  $(function () {
    app.run('#/');
  });

})(jQuery);
