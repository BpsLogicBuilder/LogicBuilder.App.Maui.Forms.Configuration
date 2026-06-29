# LogicBuilder.App.Maui.Forms.Configuration

[![CI](https://github.com/BpsLogicBuilder/LogicBuilder.App.Maui.Forms.Configuration/actions/workflows/ci.yml/badge.svg)](https://github.com/BpsLogicBuilder/LogicBuilder.App.Maui.Forms.Configuration/actions/workflows/ci.yml)
[![CodeQL](https://github.com/BpsLogicBuilder/LogicBuilder.App.Maui.Forms.Configuration/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/BpsLogicBuilder/LogicBuilder.App.Maui.Forms.Configuration/actions/workflows/github-code-scanning/codeql)
[![codecov](https://codecov.io/gh/BpsLogicBuilder/LogicBuilder.App.Maui.Forms.Configuration/graph/badge.svg?token=LR4JJ4Y03J)](https://codecov.io/gh/BpsLogicBuilder/LogicBuilder.App.Maui.Forms.Configuration)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=BpsLogicBuilder_LogicBuilder.App.Maui.Forms.Configuration&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=BpsLogicBuilder_LogicBuilder.App.Maui.Forms.Configuration)

A .NET Standard 2.0 library providing serializable descriptor classes that define the configuration and behavior of dynamic .NET MAUI forms.

## Purpose

This library provides a comprehensive set of configuration descriptor classes that enable data-driven form generation in .NET MAUI applications. Instead of hardcoding form layouts and validation logic, applications can deserialize JSON configuration files into these descriptors and use them to dynamically construct forms at runtime.

## Key Features

- **Form Structure Definitions**: Configure complete data forms including layout, controls, and nested field groups
- **Validation Configuration**: Define field-level and form-level validation rules with custom messages
- **Conditional Directives**: Implement dynamic form behavior based on runtime conditions (visibility, enabled state, etc.)
- **Multi-Select Controls**: Configure dropdown and multi-select controls with data binding
- **Template Support**: Define reusable templates for form groups and controls
- **Data Binding**: Configure multi-binding for complex display scenarios
- **CRUD Operations**: Support for Add, Update, Delete, and Detail form types
- **Request Details**: Configure data source URLs and OData query parameters for remote data

## Core Descriptor Classes

### Form Configuration
- **`DataFormSettingsDescriptor`**: Top-level form configuration including title, form type (Add/Update/Delete/Detail), validation messages, and field settings
- **`FormGroupSettingsDescriptor`**: Nested form group configuration for complex object hierarchies
- **`MultiSelectFormControlSettingsDescriptor`**: Multi-select control configuration with data source and value binding

### Validation
- **`ValidationRuleDescriptor`**: Individual validation rule with class name and error message
- **`FieldValidationSettingsDescriptor`**: Field validation configuration including default values and validators
- **`ValidatorDefinitionDescriptor`**: Validator definition with configurable parameters

### Conditional Behavior
- **`DirectiveDescriptor`**: Conditional directive pairing a definition with a condition
- **`DirectiveDefinitionDescriptor`**: Directive definition specifying the class, function, and arguments

### Data Binding & Requests
- **`MultiBindingDescriptor`**: Multi-field binding with string formatting
- **`FormRequestDetailsDescriptor`**: HTTP request configuration for CRUD operations
- **`RequestDetailsDescriptor`**: Data source request configuration with model and data type mappings

### Templates
- **`FormGroupTemplateDescriptor`**: Reusable form group template reference
- **`MultiSelectTemplateDescriptor`**: Multi-select control template with text/value selectors

## Serialization

All descriptor classes are compatible with `System.Text.Json` and support:
- Case-insensitive property name matching
- Nullable reference types
- Round-trip serialization preserving all properties

## Dependencies

- **LogicBuilder.Structures** (v8.0.2): Provides base structures for lambda descriptors, selectors, and filter definitions

## License

MIT License - Copyright © BPS 2026

## Related Projects

Part of the [LogicBuilder](https://github.com/BpsLogicBuilder/LogicBuilder) ecosystem for building data-driven applications.
