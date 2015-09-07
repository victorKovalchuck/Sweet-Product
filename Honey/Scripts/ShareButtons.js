window.fbAsyncInit = function () {
    FB.init({
        appId: '376670065855720',
        xfbml: true,
        version: 'v2.2'
    });
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
} (document, 'script', 'facebook-jssdk'));


   !function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (!d.getElementById(id)) {
            js = d.createElement(s); js.id = id;
            js.src = "//platform.twitter.com/widgets.js";
            fjs.parentNode.insertBefore(js, fjs);
        }
    } (document, "script", "twitter-wjs");


  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-53473131-2', 'auto');
  ga('send', 'pageview');

