﻿using System.ComponentModel.DataAnnotations;
using System.IO;
using Caliburn.Micro;
using FastBuild.Dashboard.Services.Build.SourceEditor;

namespace FastBuild.Dashboard.ViewModels.Settings;

public class SettingsValidator
{
    public static ValidationResult ValidateFolderPath(string folderPath, ValidationContext context)
    {
        if (!Directory.Exists(folderPath))
            return new ValidationResult("folder path not existed", new[] { nameof(SettingsViewModel.BrokeragePath) });

        return ValidationResult.Success;
    }

    public static ValidationResult ValidateCoordinatorAddress(string coordinatorAddress, ValidationContext context)
    {
        if (string.IsNullOrEmpty(coordinatorAddress))
            return new ValidationResult("Coordinator address is empty", new[] { nameof(SettingsViewModel.CoordinatorAddress) });

        return ValidationResult.Success;
    }

    public static ValidationResult ValidateExternalSourceEditorPath(string editorPath, ValidationContext context)
    {
        if (!string.IsNullOrEmpty(editorPath))
        {
            if (!File.Exists(editorPath))
                return new ValidationResult("specified editor path not existed",
                    new[] { nameof(SettingsViewModel.ExternalSourceEditorPath) });
        }
        else
        {
            if (!IoC.Get<IExternalSourceEditorService>().IsSelectedEditorAvailable)
                return new ValidationResult("the editor cannot be found at your Program Files, please locate it here",
                    new[] { nameof(SettingsViewModel.ExternalSourceEditorPath) });
        }

        return ValidationResult.Success;
    }
}