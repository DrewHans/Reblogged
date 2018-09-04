#!/bin/bash
# Author: Drew Hans (github.com/drewhans555)
# Run unit tests and generate a hard-to-read
# code coverage report (in opencover format)
# using Coverlet.

dotnet test \
-p:CollectCoverage=true \
-p:CoverletOutputFormat=opencover \
-p:CoverletOutput=./TestCoverage/report \
-p:Exclude=\"\
[*]Blog.Core.Test.*\
\"
