namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        // Propriedade para armazenar a lista de hóspedes associados a esta reserva.
        // É uma lista de objetos 'Pessoa'.
        public List<Pessoa> Hospedes { get; set; }

        // Propriedade para armazenar a suíte que foi reservada.
        // É um objeto do tipo 'Suite'.
        public Suite Suite { get; set; }

        // Propriedade para armazenar a quantidade de dias que a suíte será reservada.
        public int DiasReservados { get; set; }

        // Construtor padrão da classe Reserva.
        // Permite criar uma instância de Reserva sem inicializar as propriedades imediatamente.
        public Reserva() { }

        // Construtor da classe Reserva que recebe o número de dias reservados como parâmetro.
        public Reserva(int diasReservados)
        {
            // Atribui o valor recebido ao número de dias reservados.
            DiasReservados = diasReservados;
        }

        // Método para cadastrar os hóspedes na reserva.
        // Recebe uma lista de objetos 'Pessoa' como parâmetro.
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se o número de hóspedes é menor ou igual à capacidade da suíte.
            if (Suite.Capacidade >= hospedes.Count)
            {
                // Se a capacidade for suficiente, atribui a lista de hóspedes à propriedade 'Hospedes'.
                Hospedes = hospedes;
            }
            else
            {
                // Se a capacidade for excedida, exibe uma mensagem de erro no console.
                // A mensagem foi melhorada para ser mais dinâmica e mostrar a capacidade real da suíte.
                Console.WriteLine($"A capacidade da suíte ({Suite.Capacidade}) é menor do que o número de hóspedes ({hospedes.Count}).");
            }
        }

        // Método para cadastrar a suíte na reserva.
        // Recebe um objeto 'Suite' como parâmetro.
        public void CadastrarSuite(Suite suite)
        {
            // Atribui o objeto 'Suite' recebido à propriedade 'Suite' da reserva.
            Suite = suite;
        }

        // Método para obter a quantidade de hóspedes cadastrados na reserva.
        public int ObterQuantidadeHospedes()
        {
            // Usa o operador null-coalescing '??'.
            // Se 'Hospedes' for null, retorna 0. Caso contrário, retorna o número de elementos na lista 'Hospedes'.
            return Hospedes?.Count ?? 0;
        }

        // Método para calcular o valor total da diária da reserva.
        public decimal CalcularValorDiaria()
        {
            // Calcula o valor base da diária multiplicando os dias reservados pelo valor diário da suíte.
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica um desconto se o número de dias reservados for igual ou superior a 10.
            if (DiasReservados >= 10)
            {
                // Aplica 10% de desconto (multiplica por 0.90). O 'M' indica que é um literal decimal.
                valor *= 0.90M ; 
            }

            // Retorna o valor final da diária (com ou sem desconto).
            return valor;
        }
    }
}