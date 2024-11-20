using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using remoteops.Application.Interfaces;
using remoteops.Domain.Entities;

public class TaskExecutionService : BackgroundService
{
    private readonly ITarefaRepository _tarefaRepository;

    public TaskExecutionService(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Obtenha as tarefas a serem executadas (por exemplo, aquelas com status pendente)
            var tarefas = await _tarefaRepository.GetAllAsync();

            foreach (var tarefa in tarefas)
            {
                // Lógica para executar a tarefa
                if (tarefa.Status == false) // Supondo que "false" significa que a tarefa não foi executada
                {
                    // Aqui você pode adicionar a lógica de execução da tarefa
                    Console.WriteLine($"Executando tarefa: {tarefa.Descricao}");

                    // Marcar a tarefa como executada
                    tarefa.Status = true;
                    await _tarefaRepository.UpdateAsync(tarefa);
                }
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Espera um minuto antes de verificar novamente
        }
    }
}
