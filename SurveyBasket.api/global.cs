﻿global using Microsoft.AspNetCore.Mvc;
global using SurveyBasket.api.Models;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using SurveyBasket.api.contracts.Authentication;
global using Mapster;
global using MapsterMapper;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.IdentityModel.Tokens;
global using SurveyBasket.api.Auuthentication;
global using SurveyBasket.api.Services;
global using System.Reflection;
global using System.Text;
global using Microsoft.AspNetCore.Authorization;
global using SurveyBasket.api.contracts.polls;
global using SurveyBasket.api.Abstraction;