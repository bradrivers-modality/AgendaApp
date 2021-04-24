let accessToken;

$(document).ready(function () {
    microsoftTeams.initialize();

    getClientSideToken()
        .then((clientSideToken) => {
            console.log("clientSideToken: " + clientSideToken);
            localStorage.setItem("access_token", clientSideToken);
            return clientSideToken;
        })
        .catch((error) => {
            console.log(error);
            if (error === "invalid_grant") {
                // Display in-line button so user can consent
                $("#divError").text("Error while exchanging for Server token - invalid_grant - User or admin consent is required.");
                $("#divError").show();
                $("#consent").show();
            } else {
                // Something else went wrong
            }
        });
});

function requestConsent() {
    getToken()
        .then(data => {
            $("#consent").hide();
            $("#divError").hide();
            accessToken = data.accessToken;
            console.log("clientSideToken: " + accessToken);
            localStorage.setItem("access_token", accessToken);
        });
}

function getToken() {
    return new Promise((resolve, reject) => {
        microsoftTeams.authentication.authenticate({
            url: window.location.origin + "/authStart",
            width: 600,
            height: 535,
            successCallback: result => {

                resolve(result);
            },
            failureCallback: reason => {

                reject(reason);
            }
        });
    });
}


function getClientSideToken() {

    return new Promise((resolve, reject) => {
        microsoftTeams.authentication.getAuthToken({
            successCallback: (result) => {
                resolve(result);

            },
            failureCallback: function (error) {
                reject("Error getting token: " + error);
            }
        });

    });

}