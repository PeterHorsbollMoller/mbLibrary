# mbLibrary
Common MapBasic libraries that can be included in MapBasic development projects

These MapBasic modules can be included in your MapBasic projects to extend the out-of-the-box capability of MapBasic.
Each module holds specific procedures and functions for a certain task, like 
- the TABLELib that holds functions for working with tables, 
- the COLUMNLib for working with columns
- RIBBONLib for working with the new Ribbon interface of MapInfo Pro 64 bit
- ...

You need to include the .def files in your own module 
and link the .mbo required with your module(s) using a Mapbasic Project File (.mbp)

Also note that I'm using modules from mbLibrary in most of my other applications shared here on GitHub.
However the libraries might not be up-to-date in each of these repositories.
Often I also only include the .def and .mbo files in my other projects. 
In that way I only have one copy of the .mb (the source code) which is found here in mbLibrary

To get the most up-to-date version, use mbLibrary
