function Configure() {
    console.log("Configuring");
    microsoftTeams.initialize();
    microsoftTeams.settings.registerOnSaveHandler((saveEvent) => {
        microsoftTeams.settings.setSettings({
            websiteUrl: window.location.origin,
            contentUrl: window.location.origin + "/",
            entityId: "Configure",
            suggestedDisplayName: "Configure"
        });
        saveEvent.notifySuccess();
    });
    microsoftTeams.settings.setValidityState(true);
    console.log("Configured");
}