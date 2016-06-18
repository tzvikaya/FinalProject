app.factory('AuthService', function() {
    var currentUser = {
        user_id: -1,
        Users_Sources : []
    };

    return {
        login: function (user) {
            currentUser = user;
        },
        logout: function () {
            currentUser.id = -1;
        },
        isLoggedIn: function () {
            console.log(currentUser);
            return currentUser.user_id !== -1;
        },
        currentUser: function() { return currentUser; }
    };
});