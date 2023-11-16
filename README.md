# Database Project

# Overview

For this project, I made a C# program that creates and stores a changeable To-Do list in a cloud database.

The purpose of this project was to help me quickly learn to work with cloud databases.  I chose firebase as the cloud software to connect to because I was familiar with its name and it wasn't too hard to set up.

Here is a demonstration of the program running:

[Software Demo Video]([http://youtube.link.goes.here](https://youtu.be/8vU5_49Xyh0))

# Cloud Database

I used Firebase to create the cloud database for this project.  It was surprisingly simple and quick to set up - all I had to do was sign in, create a new project, and make a collection with an attached document within that project.  Apparently every new entry to the document has to be a key value pair, so there was some work I had to do around that, but overall it wasn't terrible.

# Development Environment

I completed this project in Microsoft Visual Studio 2022 using C# and Firebase.  I used these add-ins throughout development:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Protobuf;

# Useful Websites

I used ChatGPT to learn how to set up firebase and solve a couple of the bugs I faced, but did the rest by myself.

- [ChatGPT](https://chat.openai.com/chat)

# Future Work

- I would like to allow the user to add to the list when first running the program without restting the old list.
- I would like to connect the list to an HTML page and show the updates there.
- I would like to add the ability to create multiple separate lists and choose which list to edit.
