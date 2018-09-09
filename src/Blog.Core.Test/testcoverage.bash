#!/bin/bash
# Author: Drew Hans (github.com/drewhans555)
# Run unit tests and generate a hard-to-read code coverage report
#  (in opencover format) using Coverlet.

dotnet test \
-p:CollectCoverage=true \
-p:CoverletOutputFormat=opencover \
-p:CoverletOutput=./TestCoverage/report \
-p:Exclude=\"\
[*]Blog.Core.FileReader,\
[*]Blog.Core.FileWriter,\
[*]Blog.Core.Program,\
[*]Blog.Core.SqlServerDataAccess,\
[*]Blog.Core.Test.*\
\"

# Notes:
# - We exclude Program because it does not contain any logic.
#
# - We exclude FileReader & FileWriter because they rely on classes
#    in the System.IO namespace that are essentially unmockable due 
#    to the same reasons I mention in the paragraph explaining why 
#    we exclude SqlServerDataAccess (see below).
#
# - We exclude SqlServerDataAccess because it relies on classes
#    in the System.Data.SqlClient namespace that are essentially 
#    unmockable due to Microsoft's design decisions (i.e., using
#    sealed keyword on classes to prevent inheritance, not having
#    classes implement interfaces that define their behavior, 
#    etc.). Some things are just hard to unit test, unfortunately,
#    which is why we will just have to settle for integration tests.
#
# - We exclude everything in the Blog.Core.Test.* namespace 
#    because these files only contain test logic.
