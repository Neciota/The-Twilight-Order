@echo off
setlocal enabledelayedexpansion

rem Replace 'path_to_your_folder' with the actual path to your folder
set "folder_path='C:\Users\Rik\Documents\The Twilight Order\Map\Map Layers SVG'"

rem Navigate to the folder
cd "%folder_path%"

rem Iterate through files
for %%F in (*.*) do (
    rem Split the file name by commas
    for /f "tokens=1-7 delims=," %%a in ("%%~nF") do (
        rem Extract the fourth string
        set "new_name=%%d"
        
        rem Rename the file
        ren "%%F" "!new_name!%%~xF"
        echo Renamed %%F to !new_name!%%~xF
    )
)

endlocal