$(function () {

    var Router = Backbone.Router.extend({
        routes: {
            '': 'home',//Default route, when no hash tag is available
            'create': 'create',// Create User, when user clicks on Create button
            'edit/:id': 'edit'
        }
    });


    var genreModel = Backbone.Model.extend({
        defaults: {
            Id: null,
            Name: null
        },

        initialize: function () {

        }
    })

    var liftOfUsers = Backbone.Collection.extend({
        model: genreModel,

        //getCustomUrl: function (method) {
        //    switch (method) {
        //        case 'read':
        //            return 'http://localhost:5000/Home/Details?id=2';
        //            break;
        //        case 'create':
        //            return 'http://localhost:5000/Genre/Create';
        //            break;
        //        case 'update':
        //            return 'http://localhost:5000/Genre/Edit/' + this.id;
        //            break;
        //        case 'delete':
        //            return 'http://localhost:5000/Genre/' + this.id;
        //            break;
        //    }
        //},

        //sync: function (method, model, options) {
        //    options || (options = {});
        //    console.log('method:', method);
        //    options.url = this.getCustomUrl(method.toLowerCase());

        //    return Backbone.sync.apply(this, arguments);
        //}
        url: 'http://localhost:5000/home/GetGenres'
    })

    var listOfGenresView = Backbone.View.extend({
       // el: '.genre-management',

        render: function () {
            var self = this;
            var _genreList = new liftOfUsers();
            _genreList.fetch({
                success: function (data) {
                    console.log("hello");
                    var _genreTemplate = _.template($('#genre-list-template').html(),
                        { genres: data.models });

                    self.$el.html(_genreTemplate);

                }
                ,
                error: function (response) {
                    console.log('22',response);
                    console.log('dssd Failed to fetch by!');
                }
            })
        }
    })

    var _objlist = new listOfGenresView();
   

   
        _objlist.render();

 


});