global using Ardalis.Specification;
global using FluentValidation;
global using Hangfire;
global using Mapster;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using SmartWaterBillingSystem.Application.Behaviors;
global using SmartWaterBillingSystem.Application.Common.Constants;
global using SmartWaterBillingSystem.Application.Common.Models;
global using SmartWaterBillingSystem.Application.Contracts.BackgroundProcessor;
global using SmartWaterBillingSystem.Application.Contracts.PDF;
global using SmartWaterBillingSystem.Application.Contracts.Repositorys;
global using SmartWaterBillingSystem.Application.DTOS.Authentication;
global using SmartWaterBillingSystem.Application.DTOS.Invoice;
global using SmartWaterBillingSystem.Application.DTOS.SlideDistribution;
global using SmartWaterBillingSystem.Application.DTOS.Subscriber;
global using SmartWaterBillingSystem.Application.DTOS.Subscription;
global using SmartWaterBillingSystem.Application.DTOS.TypesOfRealEstate;
global using SmartWaterBillingSystem.Application.DTOS.WhatsAppMessage;
global using SmartWaterBillingSystem.Application.Features.Commands.Invoices.CreateInvoice;
global using SmartWaterBillingSystem.Application.Features.Commands.Invoices.CreateInvoiceEvents;
global using SmartWaterBillingSystem.Application.Features.Querys.Subscriptions.GetNextSubscriptionNumber;
global using SmartWaterBillingSystem.Domain.Entities;
global using SmartWaterBillingSystem.Domain.Specifications.Invoices;
global using SmartWaterBillingSystem.Domain.Specifications.SlideDistributions;
global using SmartWaterBillingSystem.Domain.Specifications.Subscribers;
global using SmartWaterBillingSystem.Domain.Specifications.Subscriptions;
global using SmartWaterBillingSystem.Domain.Specifications.TypesOfRealEstates;
global using System.Reflection;
global using System.Text.RegularExpressions;




