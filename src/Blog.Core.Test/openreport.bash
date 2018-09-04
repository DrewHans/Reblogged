#!/bin/bash
# Author: Drew Hans (github.com/drewhans555)
# Open the human-readable code coverage report
# with a web browser. Web Browsers are ordered
# by my personal preference.

report_path="./TestCoverage/ReportGenerator/index.htm"
if [[ ! -f $report_path ]]; then
    echo "ReportGenerator's index.htm file not found."
    echo "Try running report.bash."
    echo "Exiting script."
    exit 1
fi

if [[ -x "$(command -v chromium-browser)" ]]; then
    echo "Opening file with Chromium Browser."
    chromium-browser $report_path

elif [[ -x "$(command -v google-chrome)" ]]; then
    echo "Opening file with Google Chrome Browser."
    google-chrome $report_path

elif [[ -x "$(command -v firefox)" ]]; then
    echo "Opening file with Firefox Browser."
    firefox $report_path

elif [[ -x "$(command -v brave-bin)" ]]; then
    echo "Opening file with Brave Browser."
    brave-bin $report_path

elif [[ -x "$(command -v opera)" ]]; then
    echo "Opening file with Opera Browser."
    opera $report_path

else
    echo "No compatible web browser found."
fi
