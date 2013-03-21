MonoTouch.Rdio
==============

This is a MonoTouch binding for [Rdio iOS SDK](http://developer.rdio.com/docs/read/iOS).

Also, there is a sample project to show how to use the bindings.

Usage
-----

MonoTouch.Rdio is the binding project. To get the Rdio.dll, you may either build it in Visual Stuido or Xamarin Stuido or just run `make` in the binding directory.

After Rdio.dll is generated, add Rdio.dll into your MonoTouch app's references.

Don't forget to [apply for an API key](http://developer.rdio.com/page) to get started.

Then, call `Rdio.InitWithConsumerKeyandSecretdelegate` to initialize a `Rdio` object.

And you are good to go!

TODO
----

Improve the sample project to make full use of the binding APIs.

License
-------

    Copyright 2013 Aaron He <aaron.wei.he@gmail.com>

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
