# Lab 13: Async Inn Management System

Basic Hotel/Room management system

## Problem it solves

Described in a previous [document](https://github.com/al1s/Lab12-Relational-Databases#problem-domain)

## Design requirements
Think about the design of your website. What will it look like? What pages will exist? How do the pages interact and link to each other? For our website, we will have the following pages:

- Home Page to greet the Hotel Admin. This page will also serve as a dashboard for the other locations of the site.
- Hotels page that will allow the admin to create and edit new or existing hotels
- Rooms page where the admin will be able to create or edit new or existing rooms
- Amenities page that will allow the admin to add to their list of existing amenities
- A page where they can link the Amenities to the rooms that currently exist
- A page where they can add existing rooms to hotels

## Spec

Following the design, Create a controller for each of the pages listed above. You may “Add » Controller” on the controllers folder and scaffold out the basic CRUD operations if you wish.
Add some html and styling to your home page. Link the index action of each of the other controllers within the Home page. Throughout the week, we will slowly evolve this page to be more of a “dashboard” feel, but start the design now to start the process.

## DB Schema

![image](https://raw.githubusercontent.com/al1s/Async-Inn/master/SchemaAsyncInn.png)

## Schema description

There are six tables in the solution, and 5 relationships. There are:

- PK Room -> FK HotelRoo;
- PK Hotel -> FK HotelRoo;
- PK Amenities -> FK RoomAmenities;
- PK Layout -> FK Room;
