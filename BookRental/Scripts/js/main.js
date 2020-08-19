$(function () {

	var Genre = Backbone.Model.extend(
		{
			defaults: {
				Id: "",
				Name: ""
			},
			idAttribute: "Id",
			initialize: function () {
				console.log("Genre has been initialized");
				this.on("invalid", function (model, error) {
					console.log("Houston, we have a problem: " + error)

				});
			},

			constructor: function (attributes, options) {
				console.log('Genre\'s constructor had been called');
				Backbone.Model.apply(this, arguments);
			},

			validate: function (attr) {
				if(!attr.Name) {
					return "Invalid Genre Name supplied."
				}
			},

			getCustomUrl: function (method) {
				switch (method) {
					case 'read':
						console.log(this.id);
						return 'http://localhost:5000/Genre/Details/2';
						
						break;
					case 'create':
						return 'http://localhost:5000/Genre/Create';
						break;
					case 'update':
						return'http://localhost:5000/Genre/Edit/' + this.id;
						break;
					case 'delete':
						return'http://localhost:5000/Genre/' + this.id;
						break;
				}
			},

			sync: function (method, model, options) {
				options || (options = {});
				options.url = this.getCustomUrl(method.toLowerCase());

				return Backbone.sync.apply(this, arguments);
			}
		}
	)
	var genre_list_View = Backbone.View.extend({
		
		el: $('#genreItem'),
		
		initialize: function () {
			this.model.bind("add", this.render, this);
		},

		render: function () {
			_each(this.model, function (data) {
				this.$el.append(new genreView({
					model: data,
					
				}).render().el)
			}, this)
			
			return this;
		}

	});
	
	var genreView = Backbone.View.extend({
		tagName: "tr",
		template: _.template($("#genre-template").html()),
		render: function () {
			this.$el.html(this.template(this.model.toJSON()));
			return this;
		}
	})

	genreList = new Genre() ;

	genreList.fetch({
		success: function (response) {
			console.log(genreList.toJSON());
			
			new genre_list_View({model: genreList})
		},
		
		error: function (response) {
			console.log(response);
			console.log('Failed to fetch by!');
		}
	});


})

