cd ../../..
cd open-settings-spa

ng build --configuration=production

source_folder="dist/open-settings-spa-dist/browser"
destination_folder="../open-settings/src/OpenSettings.AspNetCore.Spa/open-settings-spa-dist"

rm -rf "$source_folder"/*.map

rm -rf "$destination_folder/browser"

mv -f "$source_folder" "$destination_folder"