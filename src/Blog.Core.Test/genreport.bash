#!/bin/bash
# Author: Drew Hans (github.com/drewhans555)
# Generate a human-readable and interactive
# HTML code coverage report using ReportGenerator.

reportgenerator_targetdir="./TestCoverage/ReportGenerator"
opencover_report_path="./TestCoverage/report.opencover.xml"

if [[ ! -f $opencover_report_path ]]; then
    echo "Opencover report file not found."
    echo "Try running test.bash."
    echo "Exiting script."
    exit 1
fi

dotnet reportgenerator \
"-reports:$opencover_report_path" \
"-targetdir:$reportgenerator_targetdir"
