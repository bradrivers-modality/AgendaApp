async function GetContext() {

    const promise = new Promise((resolve, reject) => {
        microsoftTeams.getContext(function (context) {
            resolve(context);
        });
    });

    const result = await promise;

    console.log(result);
    return result;
}